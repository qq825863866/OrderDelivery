using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Logging
{
    public interface INLogHelper
    {
        void LogError(Exception ex);
    }
}
