using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.DTOs.Project
{
    public class ShowProjectListItemViewModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string SDescription { get; set; }
        public string ProjectImage { get; set; }
    }
}
