using Microsoft.AspNetCore.Http;
using FileTypeChecker.Types;
using FileTypeChecker.Extensions;
using CloudStorageTest.Domain.Storage;
using CloudStorageTest.Domain.Entities;

namespace CloudStorageTest.Application.UseCases.Uses.UploadProfilePhoto;
public class UploadProfilePhotoUseCase
{   
    private readonly IStorageService _storageService;

    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();
        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();
        if (isImage == false)
            throw new Exception("the file is not an image");

        var user = GetFromDatabase();
        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Beatriz",
            Email = "beaferreira.trabalho@gmail.com"
        };
    }
}
