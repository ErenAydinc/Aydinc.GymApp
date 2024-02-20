using Application.Features.PersonalTrainers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Localization.Abstraction;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.PersonalTrainers.Rules;

public class PersonalTrainerBusinessRules : BaseBusinessRules
{
    private readonly IPersonalTrainerRepository _personalTrainerRepository;
    private readonly ILocalizationService _localizationService;

    public PersonalTrainerBusinessRules(IPersonalTrainerRepository personalTrainerRepository, ILocalizationService localizationService)
    {
        _personalTrainerRepository = personalTrainerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PersonalTrainersMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PersonalTrainerIsExists(int userId,bool controlIsExists=false)
    {
        PersonalTrainer<int>? getPersonalTrainer= await _personalTrainerRepository.GetAsync(x => x.UserId == userId);
        if (getPersonalTrainer == null && controlIsExists == false)
            await throwBusinessException(PersonalTrainersMessages.UserDontExists);
        else if(getPersonalTrainer != null && controlIsExists == true)
        {
            await throwBusinessException(PersonalTrainersMessages.PersonalTrainerExists);
        }
    }
}
