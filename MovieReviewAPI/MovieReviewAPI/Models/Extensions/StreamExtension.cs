using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieReviewAPI.Models.Extensions
{
    /// <summary>
    /// Stream和Byte轉換擴充方法
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// 將 Stream 轉成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(this Stream stream)
        {
            byte[] buffer = new byte[4096]; // 緩衝區，代表一次讀取大小為4096
            using (MemoryStream ms = new MemoryStream())
            {
                int read = 0;
                // 當read = -1 代表讀完了
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);

                return ms.ToArray();
            }
        }

        /// <summary>
        /// 將 byte[] 轉成 Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);

            return stream;
        }

        /// <summary>
        /// 下載Stream存到實體路徑
        /// </summary>
        /// <param name="savePath">存放路徑</param>
        /// <param name="stream">下載資料</param>
        private static void SaveFile(string savePath, Stream stream)
        {
            FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
            stream.CopyTo(fs);
            fs.Close();
        }


        /// <summary>
        /// 取得DB檔案並存到實體路徑下
        /// </summary>
        /// <param name="savePath">存放到實體路徑下的檔名</param>
        /// <param name="data">下載資料</param>
        /// <returns></returns>
        public static FileStream GetFileStream(Guid? fileId, byte[] data)
        {
            // 若沒有則隨機產生檔名
            if (fileId == null)
            {
                fileId = Guid.NewGuid();
            }

            // 取得專案根目錄
            string rootPath = System.Web.HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(rootPath, fileId.ToString());
            Stream stream = new MemoryStream(data);

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            stream.CopyTo(fs);
            fs.Close();

            return fs;
        }
    }
}