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
### �����������
��� ����������� ������� ����� ������������ ������� ���������� **StartupExtensions**.
� ���� ������ ����� ������� ������ ������ ��������

### ������ ��������
1. **PaymentService** - ������ ����������� ������������ ������ �� ������ � �� �������������
    - CreatePaymentUrl - ��������� ������ �� ������ ��� ������������
    - Verify - ������������ ������ ����� ��������� ��������� ����������� � ��������� � ��������
2. **SubscriptionService** - ������ ����������� �������� rest api prodamus. ��������� ����������
    - SetActivity - ������ ����� ������ ��� ���������� ��������� (���������/�����������) ��������
    - SetSubscriptionDiscount - ������ ����� ������ ��� ���������� ������� �� ��������
    - SetSubscriptionPaymentDate - ������ ����� ������������ ��� ��������� ���� ���������� �������