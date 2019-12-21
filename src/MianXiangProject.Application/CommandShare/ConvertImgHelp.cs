using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace MianXiangProject.CommandShare
{
    /// <summary>
    /// 图片转换
    /// </summary>
    public class ConvertImgHelp
    {
        /// <summary>
        /// Base64Img字符串转图片
        /// </summary>
        /// <param name="basestr">base64字符串</param>
        /// <returns></returns>
        public static Bitmap Base64StringToImageBitmap(string basestr)
        {
            Bitmap bitmap = null;
            try
            {
                String inputStr = basestr;
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                bitmap = bmp;
                //MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Base64StringToImage 转换失败\nException：" + ex.Message);
                Console.WriteLine("Base64StringToImage 转换失败\nException：" + ex.Message);
            }

            return bitmap;
        }
        /// <summary>
        /// 图片转base64img字符串
        /// </summary>
        /// <param name="Imagefilename"></param>
        /// <returns></returns>
        public static string ImgToBase64Stringone(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                //FileStream fs = new FileStream(Imagefilename + ".txt", FileMode.Create);
                //StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                //sw.Write(strbaser64);

                //sw.Close();
                //fs.Close();
                //MessageBox.Show("转换成功!\n" + strbaser64);
                return strbaser64;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #region base64编码的字符串转为图片
        /// <summary>
        /// base64编码的字符串转为图片
        /// </summary>
        /// <param name="strbase64"></param>
        /// <returns></returns>
        public static Image Base64StringToImage(string strbase64)
        {

            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                return img;
                //System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                //img.Save("ImgName.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //img.Save("ImgName.bmp", ImageFormat.Bmp);
                //img.Save("ImgName.gif", ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
