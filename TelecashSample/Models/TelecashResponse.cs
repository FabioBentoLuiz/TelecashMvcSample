using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecashSample.Models
{
    public class TelecashResponse
    {
        //Approval code for the transaction
        public string approval_code { get; set; }

        //Order ID 
        public string oid { get; set; }

        //Reference number 
        public string refnumber { get; set; }

        //Transaction status 
        public string status { get; set; }

        //Time of transaction processing 
        public string txndate_processed { get; set; }

        //Identification for the specific transaction, e.g. to be used for a Void
        public string tdate { get; set; }

        //Reason the transaction failed 
        public string fail_reason { get; set; }

        //Hash-Value to protect the communication
        public string response_hash { get; set; }

        //The response code provided by the backendsystem 
        public string processor_response_code { get; set; }

        //Internal processing feature in failed transactions
        public string fail_rc { get; set; }

        //The terminal ID used for the transaction
        public string terminal_id { get; set; }

        //6-digit identifier card-issuing bank
        public string ccbin { get; set; }

        //3-letter ISO code for the country of
        //Cardholder (for example USA, ENG, ITA, etc.)
        //"N / A", provided that the country can Not be determined
        //may Or Not have a credit card Is used.
        public string cccountry { get; set; }

        //Brand of the credit or debit card
        public string ccbrand { get; set; }

        //customer ID
        public string customerid { get; set; }

        //total price
        public string chargetotal { get; set; }

        //Customer name
        public string bname { get; set; }

        //Comma separated list of missing or invalid variables
        public string fail_reason_details { get; set; }

        //true – if validation of card holder data was negative
        //false – if validation of card holder data was positive but
        //transaction has been declined due To other reasons
        public string invalid_cardholder_data { get; set; }

        //a customized field (do not exists in the official documentation)
        //that we'll send and the TeleCash gives back with the same name and value
        public string myCustomerName { get; set; }
    }
}