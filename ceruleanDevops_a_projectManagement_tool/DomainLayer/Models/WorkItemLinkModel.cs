using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class WorkItemLinkModel
    {
        public int Id { get; set; }
        public string sourceWorkItemId {  get; set; }
        public string targetWorkItemId { get; set; }
        public string linkType {  get; set; }
    }
}
