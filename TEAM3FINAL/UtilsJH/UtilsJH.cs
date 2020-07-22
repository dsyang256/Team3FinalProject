using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    /// <summary>
    /// Util들을 모아둔 클래스 - 오지훈
    /// </summary>
    public class UtilsJH
    {
        /// <summary>
        /// 사진 크기를 변환하는 메서드
        /// </summary>
        /// <param name="originImage">원본이미지</param>
        /// <param name="pictureBox">변환된이미지를 담을 컨트롤</param>
        /// <returns></returns>
        public static Image ResizePicture(Image originImage, PictureBox pictureBox)
        {
            //비율
            float percent = default;
            //float nPercent = ((float)percent) / 100;

            int x = pictureBox.Width;
            int y = pictureBox.Height;

            int originX = originImage.Width;
            int originY = originImage.Height;

            int resizeX=default;
            int resizeY=default;

            if (originX > originY)
            {
                percent = ((float)x) / originX;
                resizeX = Convert.ToInt32(originX * percent);
                resizeY = Convert.ToInt32(originX * percent);
            }
            else //originX < originY  or originX == originY
            {
                percent = ((float)y) / originY;
                resizeX = Convert.ToInt32(originX * percent);
                resizeY = Convert.ToInt32(originX * percent);
            }

            Image origin = originImage;
            Image dest = new Bitmap(resizeX, resizeY,
                                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(dest))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(origin,
                    new RectangleF(0, 0, resizeX, resizeY),
                    new RectangleF(0, 0, originX, originY),
                    GraphicsUnit.Pixel);
            }
            return dest;
        }
    }

    public static class HelperExtensions
    {
        //Convert Image to byte[] array:
        public static byte[] ToByteArray(this Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        //Convert byte[] array to Image:
        public static Image ToImage(this byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }

    public class LoginInfo
    {
        #region 싱글톤
        private static LoginInfo userInfo = null;
        public static LoginInfo UserInfo
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = new LoginInfo();
                }
                return userInfo;
            }
        }
        #endregion

        #region 멤버변수
        public string LI_ID { get; set; }
        public string LI_NAME { get; set; }
        #endregion

        #region 생성자
        public LoginInfo() { }
        #endregion

        #region 메서드
        /// <summary>
        /// 멤버변수 초기화 메서드
        /// </summary>
        public void InitMember()
        {
            LI_ID = default;
            LI_NAME = default;
        }
        #endregion
    }



}

