namespace Trans2QuikAdapter.Orders
{
    using System;
    using Trans2QuikAdapter.Orders.Helpers;
    using Trans2QuikAdapter.Orders.ValueTypes;

    public class OrderBuilder
    {
        protected NameValueCodec Codec { get; private set; }

        public OrderBuilder()
        {
            this.Codec = new NameValueCodec();
        }

        public OrderBuilder Action(OrderAction action)
        {
            this.Codec.Add(Keys.Action, action.Name);
            return this;
        }

        public OrderBuilder TransId(int transId)
        {
            this.Codec.Add(Keys.TransId, transId.ToString());
            return this;
        }

        public OrderBuilder ClassCode(string classCode)
        {
            this.Codec.Add(Keys.ClassCode, classCode);
            return this;
        }

        public OrderBuilder SecCode(string secCode)
        {
            this.Codec.Add(Keys.SecCode, secCode);
            return this;
        }

        public OrderBuilder FirmId(string firmId)
        {
            this.Codec.Add(Keys.FirmId, firmId);
            return this;
        }

        public OrderBuilder Account(string account)
        {
            this.Codec.Add(Keys.Account, account);
            return this;
        }

        public OrderBuilder ClientCode(string clientCode)
        {
            this.Codec.Add(Keys.ClientCode, clientCode);
            return this;
        }

        public OrderBuilder OrderKey(ulong orderKey)
        {
            this.Codec.Add(Keys.OrderKey, orderKey.ToString());
            return this;
        }

        public OrderBuilder StopOrderKey(ulong stopOrderKey)
        {
            this.Codec.Add(Keys.StopOrderKey, stopOrderKey.ToString());
            return this;
        }

        public OrderBuilder Comment(string comment)
        {
            this.Codec.Add(Keys.Comment, comment);
            return this;
        }

        public OrderBuilder Operation(Operation operation)
        {
            this.Codec.Add(Keys.Operation, operation.Name);
            return this;
        }

        public OrderBuilder BaseContract(string baseContract)
        {
            this.Codec.Add(Keys.BaseContract, baseContract);
            return this;
        }

        public OrderBuilder MoveOrdersMode(MoveOrdersMode mode)
        {
            this.Codec.Add(Keys.MoveOrdersMode, mode.Name);
            return this;
        }

        public OrderBuilder FirstOrderNumber(ulong firstOrderNumber)
        {
            this.Codec.Add(Keys.FirstOrderNumber, firstOrderNumber.ToString());
            return this;
        }

        public OrderBuilder SecondOrderNumber(ulong secondOrderNumber)
        {
            this.Codec.Add(Keys.SecondOrderNumber, secondOrderNumber.ToString());
            return this;
        }

        public OrderBuilder FirstOrderNewPrice(double firstOrderNewPrice)
        {
            this.Codec.Add(Keys.FirstOrderNewPrice, firstOrderNewPrice.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder FirstOrderNewQuantity(long firstOrderNewQuantity)
        {
            this.Codec.Add(Keys.FirstOrderNewQuantity, firstOrderNewQuantity.ToString());
            return this;
        }

        public OrderBuilder SecondOrderNewPrice(double secondOrderNewPrice)
        {
            this.Codec.Add(Keys.SecondOrderNewPrice, secondOrderNewPrice.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder SecondOrderNewQuantity(long secondOrderNewQuantity)
        {
            this.Codec.Add(Keys.SecondOrderNewQuantity, secondOrderNewQuantity.ToString());
            return this;
        }

        public OrderBuilder Quantity(long quantity)
        {
            this.Codec.Add(Keys.Quantity, quantity.ToString());
            return this;
        }

        public OrderBuilder Price(double price)
        {
            this.Codec.Add(Keys.Price, price.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder KillActiveOrders(bool killActiveOrders)
        {
            this.Codec.Add(Keys.KillActiveOrders, new YesNo(killActiveOrders).Name);
            return this;
        }

        public OrderBuilder Type(OrderType type)
        {
            this.Codec.Add(Keys.Type, type.Name);
            return this;
        }

        public OrderBuilder MarketMakerOrder(bool marketMakerOrder)
        {
            this.Codec.Add(Keys.MarketMakerOrder, new YesNo(marketMakerOrder).Name);
            return this;
        }

        public OrderBuilder ExecutionCondition(ExecutionCondition executionCondition)
        {
            this.Codec.Add(Keys.ExecutionCondition, executionCondition.Name);
            return this;
        }

        public OrderBuilder StopPrice(double stopPrice)
        {
            this.Codec.Add(Keys.StopPrice, stopPrice.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder StopPrice2(double stopPrice2)
        {
            this.Codec.Add(Keys.StopPrice2, stopPrice2.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder StopOrderKind(StopOrderKind stopOrderKind)
        {
            this.Codec.Add(Keys.StopOrderKind, stopOrderKind.Name);
            return this;
        }

        public OrderBuilder StopPriceClassCode(string stopPriceClassCode)
        {
            this.Codec.Add(Keys.StopPriceClassCode, stopPriceClassCode);
            return this;
        }

        public OrderBuilder StopPriceSecCode(string stopPriceSecCode)
        {
            this.Codec.Add(Keys.StopPriceSecCode, stopPriceSecCode);
            return this;
        }

        public OrderBuilder BaseOrderKey(ulong baseOrderKey)
        {
            this.Codec.Add(Keys.BaseOrderKey, baseOrderKey.ToString());
            return this;
        }

        public OrderBuilder StopPriceCondition(StopPriceCondition stopPriceCondition)
        {
            this.Codec.Add(Keys.StopPriceCondition, stopPriceCondition.Name);
            return this;
        }

        public OrderBuilder LinkedOrderPrice(double linkedOrderPrice)
        {
            this.Codec.Add(Keys.LinkedOrderPrice, linkedOrderPrice.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder ExpiryDate(ExpiryDate expiryDate)
        {
            this.Codec.Add(Keys.ExpiryDate, expiryDate.Name);
            return this;
        }

        public OrderBuilder MarketStopLimit(bool marketStopLimit)
        {
            this.Codec.Add(Keys.MarketStopLimit, new YesNo(marketStopLimit).Name);
            return this;
        }

        public OrderBuilder MarketTakeProfit(bool marketStopLimit)
        {
            this.Codec.Add(Keys.MarketTakeProfit, new YesNo(marketStopLimit).Name);
            return this;
        }

        public OrderBuilder IsActiveInTime(bool isActiveInTime)
        {
            this.Codec.Add(Keys.IsActiveInTime, new YesNo(isActiveInTime).Name);
            return this;
        }

        public OrderBuilder ActiveFromTime(DateTime activeFromTime)
        {
            this.Codec.Add(Keys.ActiveFromTime, activeFromTime.ToString(Formats.TimeFormat));
            return this;
        }

        public OrderBuilder ActiveToTime(DateTime activeToTime)
        {
            this.Codec.Add(Keys.ActiveToTime, activeToTime.ToString(Formats.TimeFormat));
            return this;
        }

        public OrderBuilder KillIfLinkedOrderPartlyFilled(bool killIfLinkedOrderPartlyFilled)
        {
            this.Codec.Add(Keys.KillIfLinkedOrderPartlyFilled, new YesNo(killIfLinkedOrderPartlyFilled).Name);
            return this;
        }

        public OrderBuilder UseBaseOrderBalance(bool useBaseOrderBalance)
        {
            this.Codec.Add(Keys.UseBaseOrderBalance, new YesNo(useBaseOrderBalance).Name);
            return this;
        }

        public OrderBuilder ActivateIfBaseOrderPartlyFilled(bool activateIfBaseOrderPartlyFilled)
        {
            this.Codec.Add(Keys.ActivateIfBaseOrderPartlyFilled, new YesNo(activateIfBaseOrderPartlyFilled).Name);
            return this;
        }

        public OrderBuilder Spread(double spread)
        {
            this.Codec.Add(Keys.Spread, spread.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder SpreadUnits(Units spreadUnits)
        {
            this.Codec.Add(Keys.SpreadUnits, spreadUnits.Name);
            return this;
        }

        public OrderBuilder Offset(double offset)
        {
            this.Codec.Add(Keys.Offset, offset.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder OffsetUnits(Units offsetUnits)
        {
            this.Codec.Add(Keys.OffsetUnits, offsetUnits.Name);
            return this;
        }

        public OrderBuilder Price2(double price2)
        {
            this.Codec.Add(Keys.Price2, price2.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder Partner(string partner)
        {
            this.Codec.Add(Keys.Partner, partner);
            return this;
        }

        public OrderBuilder CurrCode(string currCode)
        {
            this.Codec.Add(Keys.CurrCode, currCode);
            return this;
        }

        public OrderBuilder LargeTrade(bool largeTrade)
        {
            this.Codec.Add(Keys.LargeTrade, new YesNo(largeTrade).Name);
            return this;
        }

        public OrderBuilder ForAccount(ForAccount forAccount)
        {
            this.Codec.Add(Keys.ForAccount, forAccount.Name);
            return this;
        }

        public OrderBuilder SettleDate(DateTime settleDate)
        {
            this.Codec.Add(Keys.SettleDate, settleDate.ToString(Formats.DateFormat));
            return this;
        }

        public OrderBuilder SettleCode(string settleCode)
        {
            this.Codec.Add(Keys.SettleCode, settleCode);
            return this;
        }

        public OrderBuilder MatchRef(string matchRef)
        {
            this.Codec.Add(Keys.MatchRef, matchRef);
            return this;
        }

        public OrderBuilder RepoValue(double repoValue)
        {
            this.Codec.Add(Keys.RepoValue, repoValue.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder StartDiscount(double startDiscount)
        {
            this.Codec.Add(Keys.StartDiscount, startDiscount.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder LowerDiscount(double lowerDiscount)
        {
            this.Codec.Add(Keys.LowerDiscount, lowerDiscount.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder UpperDiscount(double uperDiscount)
        {
            this.Codec.Add(Keys.UpperDiscount, uperDiscount.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder RepoTerm(int repoTerm)
        {
            this.Codec.Add(Keys.RepoTerm, repoTerm.ToString());
            return this;
        }

        public OrderBuilder RepoRate(double repoRate)
        {
            this.Codec.Add(Keys.RepoRate, repoRate.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder BlockSecurities(bool blockSecurities)
        {
            this.Codec.Add(Keys.BlockSecurities, new YesNo(blockSecurities).Name);
            return this;
        }

        public OrderBuilder RefundRate(double refundRate)
        {
            this.Codec.Add(Keys.RefundRate, refundRate.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder NegTradeOperation(Operation negTradeOperation)
        {
            this.Codec.Add(Keys.NegTradeOperation, negTradeOperation.Name);
            return this;
        }

        public OrderBuilder NegTradeNumber(string negTradeNumber)
        {
            this.Codec.Add(Keys.NegTradeNumber, negTradeNumber);
            return this;
        }

        public OrderBuilder VolumeMn(double volumeMn)
        {
            this.Codec.Add(Keys.VolumeMn, volumeMn.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder VolumePl(double volumePl)
        {
            this.Codec.Add(Keys.VolumePl, volumePl.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder Kfl(double kfl)
        {
            this.Codec.Add(Keys.Kfl, kfl.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder Kgo(double kgo)
        {
            this.Codec.Add(Keys.Kgo, kgo.ToString(Formats.DecimalFormat));
            return this;
        }

        public OrderBuilder UseKgo(bool useKgo) // TODO: Should use short values (Y/N)? 
        {
            this.Codec.Add(Keys.UseKgo, new YesNo(useKgo).Name);
            return this;
        }

        public OrderBuilder Correction(bool correction) // TODO: Should use short values (Y/N)? 
        {
            this.Codec.Add(Keys.Correction, new YesNo(correction).Name);
            return this;
        }

        public OrderBuilder CheckLimits(bool checkLimits)
        {
            this.Codec.Add(Keys.CheckLimits, new YesNo(checkLimits).Name);
            return this;
        }

        public override string ToString()
        {
            return this.Codec.Encode();
        }
    }
}
