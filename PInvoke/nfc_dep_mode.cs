using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNFC.PInvoke
{
    /**
     * @enum nfc_dep_mode
     * @brief NFC D.E.P. (Data Exchange Protocol) active/passive mode
     */
    public enum nfc_dep_mode
    {
        NDM_UNDEFINED = 0,
        NDM_PASSIVE,
        NDM_ACTIVE,
    }

}
