using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TEAM3FINAL
{
    /// <summary>
    /// 유효성 확인 클래스 - OJH
    /// </summary>
    public class ValidCheck
    {
        public enum contentTypes
        {
            ID = 1
           , Password = 2
           , 이름 = 3
           , Email = 4
           , 휴대폰번호 = 5
           , 숫자번호 = 6
        }

        /// <summary>
        /// Text의 유효값을 확인하는 메서드
        /// </summary>
        /// <param name="contentType">유효값확인타입</param>
        /// <param name="content">확인할 내용</param>
        /// <returns></returns>
        public static bool VaildText(contentTypes contentType, string content) //contentType => 1: ID / 2: Password / 3: 이름 / 4: Email / 5: 휴대폰번호 / 6. (11자리숫자)번호
        {
            Match match = default;
            Regex regex = default;

            switch (contentType)
            {
                case contentTypes.ID: //학생 ID는 11자 이내로 입력 , 영문소문자 및 숫자만 허용 // 문자로 시작하는 1~11자리, 숫자포함 필수
                    {
                        regex = new Regex(@"^(?=.*[a-z])(?=.*\d)[a-z\d]{1,11}$");
                        break;
                    }
                case contentTypes.Password:   //비밀번호는 8~16자 영문 대 소문자, 숫자, 특수문자만 허용한다. //최소 8자 최대 16자 , 하나이상의 대문자, 하나이상의 소문자, 하나이상의 숫자, 하나이상의 특수문자

                    {
                        regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$");
                        break;
                    }
                case contentTypes.이름: //이름은 한글만 입력 (가-힣) , 1~11자리
                    {
                        regex = new Regex(@"^(?=.*[가-힣])[가-힣\d]{1,11}$");
                        break;
                    }
                case contentTypes.Email: //이메일 :
                    {
                        regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        break;
                    }
                case contentTypes.휴대폰번호: //휴대폰번호 : (01 + 016789중의 한자리)-(0~9중의 값으로 3~4자리)-(0~9중의 값으로 4자리)
                    {
                        regex = new Regex(@"01{1}[016789]{1}-[0-9]{3,4}-[0-9]{4}");
                        break;
                    }
                case contentTypes.숫자번호: //번호 : 11자리의 숫자
                    {
                        regex = new Regex(@"^(?=.*\d)[0-9]{11}$");
                        break;
                    }
            }
            match = regex.Match(content);

            return match.Success ? true : false;
        }


    }
}
