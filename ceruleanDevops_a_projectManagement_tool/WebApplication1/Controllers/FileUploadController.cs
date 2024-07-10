﻿using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using BusinessLOgic.sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApplication1.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileService _fileUploadService;
        private readonly IMapper _mapper;
        public FileUploadController(IFileService fileUploadService,IMapper mapper)
        {
            _fileUploadService = fileUploadService;
            _mapper = mapper;
        }
        [HttpGet("getallById/{id}")]
        public async Task<IActionResult> GetFilesByWorkItemId(string id)
        {
            var result = await _fileUploadService.GetFilesWithId(id);
            var model = _mapper.Map<IEnumerable<FileModel>>(result);

            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> PostFiles([FromForm] List<IFormFile> files, [FromForm] string workItemId)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            var result = await _fileUploadService.UploadFilesAsync(files, workItemId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound("WorkItem not found.");
            }
        }
    }
}
