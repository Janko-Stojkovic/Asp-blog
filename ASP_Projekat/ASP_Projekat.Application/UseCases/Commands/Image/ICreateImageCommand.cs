using ASP_Projekat.Application.UseCases;
using ASP_Projekat.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.Commands.Image
{
    public interface ICreateImageCommand : ICommand<CreateImageDTO>
    {
    }
}
