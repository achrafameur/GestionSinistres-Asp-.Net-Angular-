using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Commands.DeleteSinisterBinder;

public class DeleteSinisterBinderCommand : IRequest
{
    public DeleteSinisterBinderCommand(int sinisterBinderId)
    {
        SinisterBinderId = sinisterBinderId;
    }

    public int SinisterBinderId { get; }
}