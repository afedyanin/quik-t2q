namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct OrderAction
    {
        public string Name { get; set; }

        public OrderAction(string name)
        {
            this.Name = name;
        }

        public static OrderAction NewOrder => new OrderAction("NEW_ORDER");                               // новая заявка
        public static OrderAction NewNegDeal => new OrderAction("NEW_NEG_DEAL");                          // новая заявка на внебиржевую сделку
        public static OrderAction NewRepoNegDeal => new OrderAction("NEW_REPO_NEG_DEAL");                 // новая заявка на сделку РЕПО
        public static OrderAction NewExtRepoNegDeal => new OrderAction("NEW_EXT_REPO_NEG_DEAL");          // новая заявка на сделку модифицированного РЕПО (РЕПО-М)
        public static OrderAction NewStopOrder => new OrderAction("NEW_STOP_ORDER");                      // новая стоп-заявка
        public static OrderAction KillOrder => new OrderAction("KILL_ORDER");                             // снять заявку
        public static OrderAction KillNegDeal => new OrderAction("KILL_NEG_DEAL");                        // снять заявку на внебиржевую сделку или заявку на сделку РЕПО
        public static OrderAction KillStopOrder => new OrderAction("KILL_STOP_ORDER");                   // снять стоп-заявку
        public static OrderAction KillAllOrders => new OrderAction("KILL_ALL_ORDERS");                    // снять все заявки из торговой системы
        public static OrderAction KillAllStopOrders => new OrderAction("KILL_ALL_STOP_ORDERS");           // снять все стоп-заявки
        public static OrderAction KillAllNegDeals => new OrderAction("KILL_ALL_NEG_DEALS");               // снять все заявки на внебиржевые сделки и заявки на сделки РЕПО
        public static OrderAction KillAllFuturesOrders => new OrderAction("KILL_ALL_FUTURES_ORDERS");     // снять все заявки на рынке FORTS
        public static OrderAction MoveOrders => new OrderAction("MOVE_ORDERS");                           // переставить заявки на рынке FORTS
        public static OrderAction NewQuote => new OrderAction("NEW_QUOTE");                               // новая безадресная заявка
        public static OrderAction KillQoute => new OrderAction("KILL_QUOTE");                             // снять безадресную заявку
        public static OrderAction NewReport => new OrderAction("NEW_REPORT");                             // новая заявка-отчет о подтверждении транзакций в режимах РПС и РЕПО
        public static OrderAction SetFutLimit => new OrderAction("SET_FUT_LIMIT");                        // новое ограничение по фьючерсному счету
    }
}
