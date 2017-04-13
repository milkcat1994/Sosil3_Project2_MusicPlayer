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
        로그인
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
        public int Length;
        public int Type;


        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        //byte단위의 패킷으로 생성.
        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        //받은 쪽에서 포장된 패킷을 원형으로 되돌리는 함수
        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 2);
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
        }
    }
}
