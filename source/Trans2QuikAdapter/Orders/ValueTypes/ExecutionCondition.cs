namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct ExecutionCondition
    {
        public string Name { get; set; }

        public ExecutionCondition(string name)
        {
            this.Name = name;
        }

        public static ExecutionCondition PutInQueue => new ExecutionCondition("PUT_IN_QUEUE");
        public static ExecutionCondition FillOrKill => new ExecutionCondition("FILL_OR_KILL");
        public static ExecutionCondition KillBalance => new ExecutionCondition("KILL_BALANCE");
    }
}
