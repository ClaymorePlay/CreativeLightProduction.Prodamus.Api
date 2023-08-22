# CreativeLightProduction.Prodamus.Api
## EN
### Connection
To connect the service, you can use ready-made extensions **StartupExtensions**.
Otherwise, you can create each service separately.

### List of services
1. **PaymentService** - a service that implements links to payment and its confirmation.
      - CreatePaymentUrl - generates a payment link for the user.
      - Verification - confirmation of payment by obtaining signatures, notifications and comparison with the server.
2. **SubscriptionService** - a service that implements the full rest api prodamus. Manages subscriptions
      - SetActivity - this method Server for managing subscription statuses (activation/deactivation)
      - SetSubscriptionDiscount - this method is used to manage the subscription discount.
      - SetSubscriptionPaymentDate - this method is intended for setting the date of the next payment

## RU
### ѕодключение
ƒл€ подключени€ сервиса можно использовать готовые расширени€ **StartupExtensions**.
¬ ином случае можно создать каждый сервис отдельно

### —писок сервисов
1. **PaymentService** - сервис реализующий формирование ссылки на оплату и ее подтверждени€
    - CreatePaymentUrl - формирует ссылку на оплату дл€ пользовател€
    - Verify - подтверждает оплату путем получени€ сигнатуры уведомлени€ и сравнени€ с сервером
2. **SubscriptionService** - сервис реализующий основное rest api prodamus. ”правл€ет подписками
    - SetActivity - данный метод служит дл€ управлени€ статусами (активаци€/деактиваци€) подписки
    - SetSubscriptionDiscount - данный метод служит дл€ управлени€ скидкой на подписку
    - SetSubscriptionPaymentDate - данный метод предназначен дл€ установки даты следующего платежа