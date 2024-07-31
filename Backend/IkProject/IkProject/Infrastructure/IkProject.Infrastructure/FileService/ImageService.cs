using IkProject.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkProject.Application.Constants;

namespace IkProject.Infrastructure.ImageService
{
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// Dosya Ekleme
        /// </summary>
        /// <param name="file">Dosya</param>
        /// <param name="root">Dosya yolu</param>
        /// <param name="userId">Dosya adına userId ekleme</param>
        /// <returns>Dosya adı</returns>
        public string Add(IFormFile file, string? userId, string? root = null)
        {
            string[] acceptedExtensions = new[] { ".png", ".bmp", ".jpg", ".jpeg",".PNG" };

            if (file.Length > 0 && CheckImage(userId, root))
            {
                string extension = Path.GetExtension(file.FileName);

                if (!acceptedExtensions.Contains(extension))
                    throw new Exception(Messages.FileTypeInvalid);

                if (!Directory.Exists(root ?? LocalPaths.ProfileImage))
                {
                    Directory.CreateDirectory(root ?? LocalPaths.ProfileImage);
                }

                userId = userId == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : userId;
                string fileName = Guid.NewGuid().ToString();
                string filePath = userId + "_" + fileName + extension;

                using (FileStream stream = File.Create((root ?? LocalPaths.ProfileImage) + filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                    return filePath;
                }
            }
            return null;
        }

        /// <summary>
        /// Dosya silme
        /// </summary>
        /// <param name="file">Dosya</param>
        /// <param name="path">Var olan doya yolu</param>
        /// <param name="fileName">Dosya adı</param>
        public void Delete(IFormFile file, string path, string fileName)
        {
            if (Directory.Exists(path + fileName))
            {
                Directory.Delete(path + fileName);
            }
        }

        /// <summary>
        /// Dosya güncelleme
        /// </summary>
        /// <param name="file">Dosya</param>
        /// <param name="filePath">Var olan dosya yolu</param>
        /// <param name="userId">Dosya adına userId ekleme</param>
        public string Update(IFormFile file, string? userId, string? root = null)
        {
            var existProfileImage = Directory.GetFiles(root ?? LocalPaths.ProfileImage, (userId + "*"));
            if (existProfileImage.Any())
            {
                File.Delete(existProfileImage[0]);

            }
            return Add(file, userId, root ?? null);

        }

        public bool CheckImage(string? userId, string? root = null)
        {
            if (root is not null)
            {
                return true;
            }

            if (Directory.EnumerateFiles(root ?? LocalPaths.ProfileImage, $"{userId}*", SearchOption.AllDirectories).Count() > 0)
            {
                return false;
            }

            return true;
        }

    }
    //public class FileHelper : IFileHelper
    //{
    //    /// <summary>
    //    /// Dosya Ekleme
    //    /// </summary>
    //    /// <param name="file">Dosya</param>
    //    /// <param name="root">Dosya yolu</param>
    //    /// <param name="userId">Dosya adına userId ekleme</param>
    //    /// <returns>Dosya adı</returns>
    //    public string Add(IFormFile file, string root, string? userId)
    //    {

    //        if (file.Length > 0 && CheckImage(root,userId))
    //        {
    //            if (!Directory.Exists(LocalPaths.ProfileImage))
    //            {
    //                Directory.CreateDirectory(LocalPaths.ProfileImage);
    //            }
    //            string extension = Path.GetExtension(file.FileName);
    //            userId = userId == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : userId;
    //            string fileName = Guid.NewGuid().ToString();
    //            string filePath = userId + "_" + fileName + extension;

    //            using (FileStream stream = File.Create(LocalPaths.ProfileImage + filePath))
    //            {
    //                file.CopyTo(stream);
    //                stream.Flush();
    //                return filePath;
    //            }
    //        }
    //        return null;
    //    }

    //    /// <summary>
    //    /// Dosya silme
    //    /// </summary>
    //    /// <param name="file">Dosya</param>
    //    /// <param name="path">Var olan doya yolu</param>
    //    /// <param name="fileName">Dosya adı</param>
    //    public void Delete(IFormFile file, string path, string fileName)
    //    {
    //        if (Directory.Exists(path + fileName))
    //        {
    //            Directory.Delete(path + fileName);
    //        }
    //    }

    //    /// <summary>
    //    /// Dosya güncelleme
    //    /// </summary>
    //    /// <param name="file">Dosya</param>
    //    /// <param name="filePath">Var olan dosya yolu</param>
    //    /// <param name="root">Kaydedilecek dosya yolu</param>
    //    /// <param name="userId">Dosya adına userId ekleme</param>
    //    public string Update(IFormFile file, string filePath, string root, string? userId)
    //    {
    //        if (File.Exists(root + filePath))
    //        {
    //            File.Delete(root + filePath);

    //        }
    //        return Add(file, root, userId);

    //    }

    //    public bool CheckImage(string root, string? userId)
    //    {
    //        switch (root)
    //        {
    //            case var a when LocalPaths.ProfileImage==root:
    //                if(Directory.EnumerateFiles(LocalPaths.ProfileImage, $"{userId}*", SearchOption.AllDirectories).Count()>0)
    //                {
    //                    return false;
    //                }
    //                break;

    //            default:
    //                break;
    //        }

    //        return true;
    //    }

    //}

}