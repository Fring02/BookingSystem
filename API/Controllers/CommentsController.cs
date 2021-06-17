using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core.Helpers;
using Domain.Core.Helpers.Exceptions;
using Domain.Core.Models.Booking;
using Domain.Dtos.Booking;
using Domain.Interfaces.Services.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [ApiController]
    //[Authorize(Roles = Roles.USER)]
    [Route("/api/v1/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CommentViewDto>> GetAllComments(Guid serviceId = default)
        {
            IEnumerable<Comment> comments;
            if (serviceId != default)
            {
                comments = await _service.GetByServiceIdAsync(serviceId);
            }
            else
            {
                comments = await _service.GetAllAsync();
            }
            return _mapper.Map<IEnumerable<CommentViewDto>>(comments ?? new List<Comment>());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<CommentViewDto> GetCommentById(int id)
        {
            return _mapper.Map<CommentViewDto>(await _service.GetByIdAsync(id) ?? new Comment());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);
            }
            var model = _mapper.Map<Comment>(dto);
            try
            {
                model = await _service.CreateAsync(model);
                return Created(Request.Path, model.Id);
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create comment");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);
            }
            var model = _mapper.Map<Comment>(dto);
            model.Id = id;
            try
            {
                await _service.UpdateAsync(model);
                return Ok("Updated comment");
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to update comment");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _service.GetByIdAsync(id);
            if (comment == null) return BadRequest("Not found comment by id " + id);
            if (await _service.DeleteAsync(comment))
            {
                return Ok("Deleted comment");
            }
            return StatusCode(500, "Failed to delete comment");
        }
    }
}