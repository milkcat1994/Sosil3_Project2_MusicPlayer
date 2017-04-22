using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//추가해주어야함
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HW2_Packet_Form
{
    public enum PacketType
    {
        초기화 = 0,
        로그인 = 1,
        리스트 = 2,
        client_Request =3,
        server_Music =4,
        end_Stream = 5,
    }

    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    //클래스를 통해 login, write 등의 패킷을 분류하는 코드이다.
    //아래 serializable는 직렬화로써 타입이 다른 것들을 이 기능을 통해
    //헤더를 달아 데이터를 일관되게 패킷으로 생성할 수 있다.
    [Serializable]
    public class Packet
    {
        public const int buffer_Size = 1024 * 3;
        public int Length;
        public int Type;
        public byte[] buffer = null;


        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }
        /*
        //byte단위의 패킷으로 생성.
        public static byte[] Serialize(Object o, int size)
        {
            using (MemoryStream ms = new MemoryStream(size))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                byte[] bytes = ms.ToArray();
                ms.Flush();
                return bytes;
            }
        }
        */

            public static byte[] Serialize(Object o, int size)
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter
                        = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(stream, o);

                    byte[] bytes = stream.ToArray();
                    stream.Flush();

                    return bytes;
                }
            }
        public static object Deserialize(byte[] binaryObj, int size)
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(binaryObj))
            {
                stream.Position = 0;
                object desObj = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream);
                return desObj;
            }
        }
        /*
        //받은 쪽에서 포장된 패킷을 원형으로 되돌리는 함수
        public static Object Deserialize(byte[] bt, int size)
        {
            using (MemoryStream ms = new MemoryStream(size))
            {
                foreach (byte b in bt)
                {
                    ms.WriteByte(b);
                }

                ms.Position = 0;
                BinaryFormatter bf = new BinaryFormatter();
                Object obj = bf.Deserialize(ms);
                ms.Close();
            return obj;
            }
        }
        */
    }

    //두개의 타입의 패킷을 만들어 두었음
    //추가적으로 사용하는 기능을 추가해주었음
    [Serializable]
    public class Initialize : Packet
    {
        public int Data = 0;
    }

    [Serializable]
    public class Login : Packet
    {
        public string m_strID;

        public Login()
        {
            this.m_strID = null;
            this.Type = 1;
        }
    }

    [Serializable]
    public class MusicList : Packet
    {
        //음악 
        public string music_Name;
        public string music_Singer;
        public string music_Play_Time;
        public string music_Bit_Rate;

        public MusicList()
        {
            this.music_Name = null;
            this.music_Singer = null;
            this.music_Play_Time = null;
            this.music_Bit_Rate = null;
            this.Type = 2;
        }
    }

    [Serializable]
    public class ClientRequest : Packet
    {
        public enum RequestType
        {
            music_File,
        }

        //요청 타입
        public RequestType request_type;
        //선택한 뮤직 이름
        public string music_Name;

        public ClientRequest(RequestType request_type)
        {
            this.request_type = request_type;
            this.music_Name = null;
            this.Type = 3;
        }
    }

    [Serializable]
    public class ServerMusic : Packet
    {
        //음악 
        public string music_Name;
        public ServerMusic()
        {
            this.music_Name = null;
            this.Type = 4;
            this.buffer = new byte[Packet.buffer_Size];
        }
    }

    [Serializable]
    public class EndStream : Packet
    {
        //음악 
        public string music_Name;
        public string music_Singer;
        public string music_Play_Time;
        public string music_Bit_Rate;

        public EndStream()
        {
            this.music_Name = null;
            this.music_Singer = null;
            this.music_Play_Time = null;
            this.music_Bit_Rate = null;
            this.Type = 5;
        }
    }
}
