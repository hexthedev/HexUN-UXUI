using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexUN.UXUI
{
    /// <summary>
    /// Can be notified when this changes
    /// </summary>
    public interface IChangeTrackable
    {
        /// <summary>
        /// Invoked when changes
        /// </summary>
        event Action OnChange;
    }
}
