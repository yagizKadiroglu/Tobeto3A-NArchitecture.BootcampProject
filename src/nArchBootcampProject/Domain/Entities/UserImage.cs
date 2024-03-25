using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;


public class UserImage:Entity<Guid>
{
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }


    public UserImage()
    {
        
    }
    public UserImage(Guid id, Guid userId, string imagePath)
    {
        Id = id;
        UserId = userId;
        ImagePath = imagePath;
    }
}
