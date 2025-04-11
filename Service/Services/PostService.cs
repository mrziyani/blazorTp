using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using Service.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;


        public PostService(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetPostByIdAsync(id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            return await _postRepository.CreatePostAsync(post);
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            return await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeletePostAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _commentRepository.GetCommentsByPostIdAsync(postId);
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            return await _commentRepository.CreateCommentAsync(comment);
        }

        //go
        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
        {
            return await _postRepository.GetPostsByUserIdAsync(userId);
        }
        public async Task<IEnumerable<CommentWithUserDto>> GetCommentsByPostWithUsersAsync(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
            return _mapper.Map<IEnumerable<CommentWithUserDto>>(comments);
        }

        //

        public async Task<DAL.Models.PostDto1> reda(int id)
        {
            var post = await _postRepository.reda(id); // suppose que c’est un Post
            return _mapper.Map<DAL.Models.PostDto1>(post);
        }


    }

}
