# Recurly .NET Client

The Official .NET [Recurly API](https://docs.recurly.com/api) client library.

Compatible with .NET >=3.5 and Recurly API v2.

## Installation

If you use [NuGet](http://www.nuget.org/), simply run the following:

```sh
PM> Install-Package recurly-api-client
```

You may also visit our [Releases](https://github.com/recurly/recurly-client-net/releases) page to download the latest version. Then add the `Recurly.dll` as a [reference](http://msdn.microsoft.com/en-us/library/hh708954.aspx) to your solution.

Alternatively, you can use use [git](http://git-scm.com/) to work with the latest changes in **development**.

```sh
git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly
```

For more information about getting started with git, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration

Specify your [API Key, site subdomain, private key](https://app.recurly.com/go/developer/api_access), and (optionally) page size setting in your `app.config` or `web.config` file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="recurly" type="Recurly.Configuration.Section,Recurly"/>
  </configSections>

  <recurly
    apiKey="123456789012345678901234567890ab"
    privateKey="123456789012345678901234567890cd"
    subdomain="company"
	pageSize="50" /> <!-- optional. 50 is the default -->

</configuration>
```

## Client Documentation

Full C# API documentation [available here](./examples.md).

### Example usage
To create an account with `account code` and `name`:

```c#
var account = new Account("123")
{
	FirstName = "John",
	LastName = "Smith"
}
account.Create();
```

Get the account with `account code` 123:

```c#
var account = Accounts.Get("123");
```

List all available `Accounts` and print their `account codes`:

```c#
var accounts = Accounts.List();
foreach (var account in accounts)
	Console.WriteLine(account.AccountCode);
```

Get an account's billing information:

```c#
var account = Accounts.Get("123");
var info = account.BillingInfo;
```

Create a coupon with code **WINTER**, name, and with a 10% discount:

```c#
var coupon = new Coupon("WINTER", "Winter discount", 10);
coupon.Create();
```

Redeem that coupon on an account that uses US dollars, getting a `CouponRedemption` object:

```c#
var redemption = account.RedeemCoupon("WINTER", "USD");
```

Each section of the API (Accounts, Invoices, Transactions, etc.) has static references for getting or listing their types and concrete implementations for manipulating concrete objects.

## Recurly API Documentation

Please see the [Recurly API](https://docs.recurly.com/api) for more information.

## Support
Looking for help? Please contact [support@recurly.com](mailto:support@recurly.com) or visit [support.recurly.com](https://support.recurly.com).

[Stackoverflow](http://stackoverflow.com/questions/tagged/recurly) is also a great place to talk to the community and find answers to common questions.

## Announcements

For the latest API and client library announcements follow Recurly on [Twitter](https://twitter.com/recurly) and join our [Google Group](http://groups.google.com/group/recurly-api):

- [@recurly](https://twitter.com/recurly)
- [Recurly Google Group](http://groups.google.com/group/recurly-api)
