using TrainingCenters.Models;
using TrainingCenters.Models.Email;
using TrainingCenters.Models.ModelMN;
namespace TrainingCenters.InterfacesApi
{
    public interface ISendEmail
    {
        Task<bool> SendEmailText(Message message, string tk);
    }
}
