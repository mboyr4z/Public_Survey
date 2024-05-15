using Entities;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class CommentatorRepository : RepositoryBase<Commentator>, ICommentatorRepository
    {
        public CommentatorRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateCommentator(Commentator commentator) => Create(commentator);

        public void Delete(Commentator commentator) => Remove(commentator);


   

            public IQueryable<Commentator> GetAllCommentatorsWithDetails(CommentatorRequestParameters pr)
        {
            IQueryable<Commentator> commentators = GetAllCommentators(false);

             return  commentators.FilteredByName( pr.Name)
                .FilteredBySurname( pr.Surname)
                .FilteredByLikeRate(pr.minLikeRate, pr.maxLikeRate, pr.IsValidLikeRate) as IQueryable<Commentator>;

            return commentators;
        }

        public void UpdateOneCommentator(Commentator entity)
        {
            Update(entity);
        }
        public IQueryable<Commentator> GetAllCommentators(bool trackChanges) => FindAll(trackChanges);




        public Commentator? GetOneCommentator(string id, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trackChanges);
        }

    }
}