using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using WorkCommon.Behaviors;

namespace WorkCommon.Manager.LayoutMgr
{
    [Export(typeof(ILayoutManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LayoutManager : ILayoutManager
    {
        /// <summary> 是否已经组合视图 </summary>
        public bool IsCombinedView { get; private set; }

        /// <summary> 导出容器 </summary>
        private AutoPopulateExportedViewsBehavior viewsManager;

        /// <summary> 事件管理器 </summary>
        private IEventAggregator eventAggregator;

        /// <summary> 主窗口界面接口 </summary>
        private IShell shell;

        [ImportingConstructor]
        public LayoutManager(IEventAggregator eventaggregator, IShell shell, AutoPopulateExportedViewsBehavior viewsmanager)
        {
            this.eventAggregator = eventaggregator;
            this.shell = shell;
            this.viewsManager = viewsmanager;
        }

        public void CombineViewPart()
        {
            InitViewPart();
            FillDockingManager();
        }

        /// <summary>
        /// 初始化导出视图
        /// </summary>
        private void InitViewPart()
        {
            if (IsCombinedView == false)
            {
                object temp = null;
                foreach (var item in viewsManager.RegisteredViews)
                {
                    if (item.IsValueCreated == false && item.Metadata.IsNeedInitialize)
                    {
                        temp = item.Value;
                    }
                }
                IsCombinedView = true;
            }
        }

        /// <summary>
        /// 填充DockingManager,即组装各个组件
        /// </summary>
        private void FillDockingManager()
        {
            //viewList.Clear();
            //foreach (var item in this.dockingManager.Layout.Descendents().OfType<LayoutAnchorable>())
            //{
            //LayoutAnchorable anchorable = item as LayoutAnchorable;
            //var view = viewsManager.GetRegionView(anchorable.ContentId);
            //viewList.Add(anchorable.ContentId, anchorable);
            //anchorable.Content = view;
            //}
        }

        /// <summary>
        /// 获取对应的视图区域
        /// </summary>
        /// <param name="regionName"></param>
        /// <returns></returns>
        private object GetViewPart(string regionName)
        {
            return viewsManager.GetRegionView(regionName);
        }

    }
}
