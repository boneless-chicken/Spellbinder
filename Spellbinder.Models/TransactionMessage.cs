using System;
using System.Collections.Generic;
using System.Text;

namespace Spellbinder.Models
{
    public class TransactionMessage
    {
        public string Thing { get; set; }
        public string TrxDate { get; set; }
        public string TrxTime { get; set; }
        public string TrxAmount { get; set; }
        public string TrxReference { get; set; }
        public string TrxRoomNbr { get; set; }
        public string TrxCurrency { get; set; }
        public string TrxPaymentMode { get; set; }
        public string TrxUser { get; set; }
        public string TrxFValue { get; set; }
        public string TrxAuth { get; set; }
        public string TrxResult { get; set; }
        public string TrxResultCode { get; set; }
        public string TrxDescription { get; set; }
        public string TrxCard { get; set; }
        public string TrxOrgNumber { get; set; }
        public string TrxMerchant { get; set; }
        public string TrxAID { get; set; }
        public string TrxArqc { get; set; }
        public string TrxCardBrand { get; set; }
        public string TrxCardBank { get; set; }
        public string TrxCardInstrument { get; set; }
    }
}
