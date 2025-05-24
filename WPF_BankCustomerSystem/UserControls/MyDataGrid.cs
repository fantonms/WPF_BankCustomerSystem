using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_BankCustomerSystem.UserControls
{
    [TemplatePart(Name = PART_Right, Type = typeof(DataGridScrollView))]
    [TemplatePart(Name = DG_ScrollViewer, Type = typeof(ScrollViewer))]
    public class MyDataGrid : DataGrid
    {
        private const string PART_Right = "PART_Right";
        private const string DG_ScrollViewer = "DG_ScrollViewer";

        private DataGridScrollView _rightDataGrid;
        private ScrollViewer _rightScrollViewer;
        private ScrollViewer _scrollViewer;

        public int RightFrozenCount
        {
            get { return (int)GetValue(RightFrozenCountProperty); }
            set { SetValue(RightFrozenCountProperty, value); }
        }

        public static readonly DependencyProperty RightFrozenCountProperty =
            DependencyProperty.Register(nameof(RightFrozenCount), typeof(int), typeof(MyDataGrid),
                new PropertyMetadata(0, OnRightFrozenCountChanged));

        private static void OnRightFrozenCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyDataGrid dataGridRightFrozen)
            {
                dataGridRightFrozen.OnRightFrozenCountChanged();
            }
        }

        private void OnRightFrozenCountChanged()
        {
            if (_rightDataGrid != null)
            {
                if (RightFrozenCount > 0)
                {
                    for (int i = 0; i < _rightDataGrid.Columns.Count; i++)
                    {
                        var column = _rightDataGrid.Columns[i];
                        _rightDataGrid.Columns.Remove(column);
                        Columns.Add(column);
                    }
                    for (int i = 0; i < RightFrozenCount; i++)
                    {
                        var last = Columns[Columns.Count - 1];
                        Columns.Remove(last);

                        _rightDataGrid.Columns.Insert(0, last);
                    }
                    _rightDataGrid.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                }
                else
                {
                    _rightDataGrid.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
                }
            }
        }

        static MyDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyDataGrid), new FrameworkPropertyMetadata(typeof(MyDataGrid)));
        }

        public MyDataGrid()
        {
            Loaded += MyDataGrid_Loaded;
        }

        private void MyDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            OnRightFrozenCountChanged();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (_scrollViewer != null)
            {
                _scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
            }
            if (_rightScrollViewer != null)
            {
                _rightScrollViewer.ScrollChanged -= RightScrollViewer_ScrollChanged;
            }
            if (_rightDataGrid != null)
            {
                _rightDataGrid.ScrollViewerChanged -= ScrollViewerChanged;
                _rightDataGrid.SelectionChanged -= RightDataGrid_SelectionChanged;
            }

            _scrollViewer = GetTemplateChild(DG_ScrollViewer) as ScrollViewer;
            if (_scrollViewer != null)
            {
                _scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }

            _rightDataGrid = GetTemplateChild(PART_Right) as DataGridScrollView;
            if (_rightDataGrid != null)
            {
                _rightDataGrid.ScrollViewerChanged += ScrollViewerChanged;
                _rightDataGrid.SelectionChanged += RightDataGrid_SelectionChanged;
            }
            SelectionChanged += DataGridRightFrozen_SelectionChanged;
        }

        private void ScrollViewerChanged(ScrollViewer viewer)
        {
            _rightScrollViewer = viewer;
            _rightScrollViewer.ScrollChanged += RightScrollViewer_ScrollChanged;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _rightScrollViewer?.ScrollToVerticalOffset(_scrollViewer.VerticalOffset);
        }

        private void RightScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _scrollViewer?.ScrollToVerticalOffset(_rightScrollViewer.VerticalOffset);
        }

        private void RightDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetCurrentValue(SelectedItemProperty, _rightDataGrid.SelectedItem);
        }

        private void DataGridRightFrozen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _rightDataGrid.SetCurrentValue(SelectedItemProperty, SelectedItem);
        }
    }

    [TemplatePart(Name = DG_ScrollViewer, Type = typeof(ScrollViewer))]
    public class DataGridScrollView : DataGrid
    {
        private const string DG_ScrollViewer = "DG_ScrollViewer";
        public ScrollViewer ScrollViewer { get; set; }

        public Action<ScrollViewer> ScrollViewerChanged;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ScrollViewer = GetTemplateChild(DG_ScrollViewer) as ScrollViewer;
            ScrollViewerChanged?.Invoke(ScrollViewer);
        }
    }
}
