#include "statusinfo.h"

StatusInfo::StatusInfo()
{
    loggedin = false;
    connect(&nam, SIGNAL(finished(QNetworkReply*)), this, SLOT(readReply(QNetworkReply*)));
    login();
}

void StatusInfo::run()
{
    while(!loggedin)
        msleep(200);

    forever
    {
        qDebug() << "working";

        QNetworkRequest request;
        request.setUrl(QUrl("http://192.168.2.1/apply.cgi"));
        request.setRawHeader("Cookie", cookie.toLocal8Bit());
        request.setRawHeader("Content-Type", "application/x-www-form-urlencoded");

        QByteArray data;
        data.append("submit_button=wimaxinterfaceInfo&submit_type=ref&change_action=gozila_cgi");

        nam.post(request, data);

        msleep(2000);
    }
}

void StatusInfo::login()
{
    QNetworkRequest request;
    request.setUrl(QUrl("http://192.168.2.1/apply.cgi"));
    request.setRawHeader("Content-Type", "application/x-www-form-urlencoded");

    QByteArray data;
    data.append("submit_button=login&submit_type=do_login&change_action=gozila_cgi&username=admin&passwd=admin");

    nam.post(request, data);
}

void StatusInfo::readReply(QNetworkReply *reply)
{
    QString response = reply->readAll();

    if(response == "success")
    {
        loggedin = true;
        emit loggedIn();

        cookie = reply->rawHeader("Set-Cookie");
        cookie.remove("; Path=/");
    }
    else
    {
        emit statusUpdated(response);
    }
}
