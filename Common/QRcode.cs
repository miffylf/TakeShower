using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Remoting.Contexts;

namespace Common
{
    public class QRcode
    {
        public static Bitmap CreateQRcode(string Message)
        {
            // 生成二维码的内容
            string strCode = Message;
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);

            // qrcode.GetGraphic 方法可参考最下发“补充说明”
            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Jpeg);

            return qrCodeImage;
            // 如果想保存图片 可使用  qrCodeImage.Save(filePath);

            //// 响应类型
            //Context.Response.ContentType = "image/Jpeg";
            ////输出字符流
            //context.Response.BinaryWrite(ms.ToArray());
        }


    }
}
