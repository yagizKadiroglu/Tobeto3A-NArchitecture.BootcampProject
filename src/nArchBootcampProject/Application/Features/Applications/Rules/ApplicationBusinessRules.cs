using Application.Features.Applications.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Applications.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicationBusinessRules(IApplicationRepository applicationRepository, ILocalizationService localizationService)
    {
        _applicationRepository = applicationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ApplicationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ApplicationShouldExistWhenSelected(Domain.Entities.Application? application)
    {
        if (application == null)
            await throwBusinessException(ApplicationsBusinessMessages.ApplicationNotExists);
    }

    public async Task ApplicationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Domain.Entities.Application? application = await _applicationRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationShouldExistWhenSelected(application);
    }
}
