﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest: IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
    }
}
