using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyCommission
{
    public class UpdateWarrantyCommissionCommand : IRequest
    {
        public UpdateWarrantyCommissionCommand(int id,int? rank, int? codeAgence, string? libelleAgence)
        {
            Id = id;
            Rank = rank;
            CodeAgence = codeAgence;
            LibelleAgence = libelleAgence;
        }

        public int Id { get; set; }
        public int? Rank { get; set; }
        public int? CodeAgence { get; set; }
        public string? LibelleAgence { get; set; }
    }
}
