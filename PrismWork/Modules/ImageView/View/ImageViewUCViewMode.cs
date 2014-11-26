using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using WorkCommon.Behaviors;
using WorkCommon.Manager;
using WorkCommon.ViewModel;

namespace ImageView
{
    [Export(typeof(ImageViewUCViewMode))]
    public class ImageViewUCViewMode : BaseObject
    {

        [ImportingConstructor]
        public ImageViewUCViewMode(IEventAggregator eventAggregator)
        {

        }
    }
}
