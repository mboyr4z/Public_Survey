using Entities;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class CommenterRepository : RepositoryBase<Commenter>, ICommenterRepository
    {
        public CommenterRepository(RepositoryContext context) : base(context)
        {

        }


        public void CreateCommenter(Commenter commenter) => Create(commenter);

        public void Delete(Commenter commenter) => Remove(commenter);


   

            public IQueryable<Commenter> GetAllCommentersWithDetails(CommenterRequestParameters pr)
        {
            IQueryable<Commenter> commenters = GetAllCommenters(false)
                .FilteredByName(commenter => commenter.Name, pr.Name)
                .FilteredBySurname(commenter => commenter.Surname, pr.Surname)
                .FilteredByLikeRate(commenter => (int)commenter.LikeRate, pr.minLikeRate, pr.maxLikeRate, pr.IsValidLikeRate);

            return commenters;
        }

        public void UpdateOneCommenter(Commenter entity)
        {
            Update(entity);
        }
        public IQueryable<Commenter> GetAllCommenters(bool trackChanges) => FindAll(trackChanges);




        public Commenter? GetOneCommenter(string id, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(id), trackChanges);
        }

    }
}