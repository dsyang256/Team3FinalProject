using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
//API의 메시지를 일정한 형식으로 전달하기 위한 클래스들
//클라이언트와 DAC 모두에서 참조해서 같은 형식으로 주고받기가능.=> DTO에 선언한 이유
{
    public class Message<T> //메시지와 데이터를 주기위한 제네릭클래스
    {
        public Message() { }

        public Message(Exception err)
        {
            IsSuccess = false;
            ResultMessage = err.Message;
            Data = default;
        }
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
        public T Data { get; set; }
    }

    public class Message //메시지만 전달하는 클래스
    {
        public Message() { }
        public Message(Exception err)
        {
            IsSuccess = false;
            ResultMessage = err.Message;
        }
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
    }
}
