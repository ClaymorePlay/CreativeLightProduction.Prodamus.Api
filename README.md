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
### Подключение
Для подключения сервиса можно использовать готовые расширения **StartupExtensions**.
В ином случае можно создать каждый сервис отдельно

### Список сервисов
1. **PaymentService** - сервис реализующий формирование ссылки на оплату и ее подтверждения
    - CreatePaymentUrl - формирует ссылку на оплату для пользователя
    - Verify - подтверждает оплату путем получения сигнатуры уведомления и сравнения с сервером
2. **SubscriptionService** - сервис реализующий основное rest api prodamus. Управляет подписками
    - SetActivity - данный метод служит для управления статусами (активация/деактивация) подписки
    - SetSubscriptionDiscount - данный метод служит для управления скидкой на подписку
    - SetSubscriptionPaymentDate - данный метод предназначен для установки даты следующего платежа