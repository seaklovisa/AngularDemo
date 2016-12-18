using CodecHelper;
using CodecHelper.Base32Codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace ServicesPoint {

    /// <summary>
    ///CodecServiceM 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class CodecServiceM : System.Web.Services.WebService {

        [WebMethod]
        public void Base32Encryptor(string input) {
            string callback = HttpContext.Current.Request["callback"];

            byte[] byteInput = Encoding.ASCII.GetBytes(input);
            IEncryptor encrytor = new Base32Encryptor();
            byte[] byteResult = encrytor.Encrypt(byteInput);
            string strResult = Base32Object.GetEncodeStrResult(byteResult);

            string response = "{\"result\":\"" + strResult + "\"}";
            string call = callback + "(" + response + ")";
            HttpContext.Current.Response.Write(call);
            HttpContext.Current.Response.End();
        }

        [WebMethod]
        public void Base32Decryptor(string input) {
            string callback = HttpContext.Current.Request["callback"];

            IDecryptor decryptor = new Base32Decryptor();
            byte[] byteResult = decryptor.Decrypt(input);
            string strResult = Base32Object.GetDecodeStrResult(byteResult);

            string response = "{\"result\":\"" + strResult + "\"}";
            string call = callback + "(" + response + ")";
            HttpContext.Current.Response.Write(call);
            HttpContext.Current.Response.End();
        }
    }
}