#ifndef STATUSINFO_H
#define STATUSINFO_H

#include <QNetworkAccessManager>
#include <QNetworkCookieJar>
#include <QNetworkRequest>
#include <QNetworkReply>
#include <QThread>

class StatusInfo : public QThread
{
    Q_OBJECT

public:
    StatusInfo();
    void run();
    void login();

signals:
    void statusUpdated(QString);
    void loggedIn();

private slots:
    void readReply(QNetworkReply* reply);

private:
    QNetworkAccessManager nam;
    QNetworkCookieJar ncj;
    QString cookie;
    bool loggedin;
};

#endif // STATUSINFO_H
