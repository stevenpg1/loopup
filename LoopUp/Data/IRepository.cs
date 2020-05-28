using LoopUp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoopUp.Data
{
    public interface IRepository
    {
        List<UKFormatter> GetUKFormats();
    }
}
