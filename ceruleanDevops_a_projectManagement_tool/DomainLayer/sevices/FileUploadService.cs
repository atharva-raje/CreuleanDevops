using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class FileUploadService : IFileService
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository fileRespository;
        private readonly IWorkItemsRespository workitemRespository;

        public FileUploadService(IFileRepository _fileRespository, IMapper mapper, IWorkItemsRespository _userRepository)
        {
            _mapper = mapper;
            fileRespository = _fileRespository;
            workitemRespository = _userRepository;
        }

        public async Task<bool> Deletefile(int id)
        {
            var result = await fileRespository.DeletefileAsync(id);
            if(result)
            {
                return true;
            }
            else
            {
                return false;
            }
             
        }

        public async Task<FileUploads> GetFileByFileId(int id)
        {
            return await fileRespository.GetFilesByFileIdAsync(id);
        }

        public async Task<IEnumerable<FileUploads>> GetFilesWithId(string id)
        {
            return await fileRespository.GetFilesByIdAsync(id); 
        }

        public async Task<bool> UploadFilesAsync(List<IFormFile> files, string workItemId)
        {
            var workItem = await workitemRespository.GetWorkitemByIdAsync(workItemId);
            if (workItem == null)
            {
                return false;
            }

            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    var fileUpload = new FileUploads
                    {
                        FileName = file.FileName,
                        FileData = memoryStream.ToArray(),
                        ContentType = file.ContentType,
                        UploadDate = DateTime.Now,
                        Size = file.Length,
                        WorkItemId = workItemId
                    };

                    await fileRespository.AddFileAsync(fileUpload);
                }
            }

            return true;
        }
    }
}
