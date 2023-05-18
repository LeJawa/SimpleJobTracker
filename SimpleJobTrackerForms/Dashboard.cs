using System.Net;
using System.Text;
using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerLibrary.Requests;

namespace SimpleJobTrackerForms
{
    public partial class Dashboard : Form
    {
        IDataRequester<JobOfferDto> _requester;


        public Dashboard()
        {
            InitializeComponent();

            _requester = new HttpRequester();
        }
    }
}