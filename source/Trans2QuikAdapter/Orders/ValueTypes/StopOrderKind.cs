namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct StopOrderKind
    {
        public string Name { get; set; }

        public StopOrderKind(string name)
        {
            this.Name = name;
        }

        public static StopOrderKind StopLimit => new StopOrderKind("SIMPLE_STOP_ORDER"); 
        public static StopOrderKind ConditionPriceByOtherSec => new StopOrderKind("CONDITION_PRICE_BY_OTHER_SEC"); 
        public static StopOrderKind WithLinkedLimitOrder => new StopOrderKind("WITH_LINKED_LIMIT_ORDER"); 
        public static StopOrderKind TakeProfit => new StopOrderKind("TAKE_PROFIT_STOP_ORDER"); 
        public static StopOrderKind TakeProfitAndStopLimit => new StopOrderKind("TAKE_PROFIT_AND_STOP_LIMIT_ORDER"); 
        public static StopOrderKind ActivatedByOrderStopLimit => new StopOrderKind("ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER"); 
        public static StopOrderKind ActivatedByOrderTakeProfit => new StopOrderKind("ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER"); 
        public static StopOrderKind ActivatedByOrderTakeProfitAndStopLimit => new StopOrderKind("ACTIVATED_BY_ORDER_TAKE_PROFIT_AND_STOP_LIMIT_ORDER"); 
    }
}
