#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    setWindowTitle("Bilai PnP GUI");

    stat = new StatusInfo();

    connect(stat, SIGNAL(loggedIn()), this, SLOT(loggedIn()));
    connect(stat, SIGNAL(statusUpdated(QString)), this, SLOT(setStatus(QString)));

    stat->start();
}

MainWindow::~MainWindow()
{
    stat->terminate();
    stat->wait();
    delete ui;
}

void MainWindow::loggedIn()
{
    statusBar()->showMessage("Login success");
}

void MainWindow::setStatus(QString info)
{
    QStringList data = info.split(';');

    QString statusBarText = data[0].toLower();
    statusBarText[0] = statusBarText[0].toUpper();
    statusBar()->showMessage(statusBarText);

    ui->bsid->setText(data[1]);
    ui->freq->setText(data[2]);
    ui->cinr->setText(data[4]);
    ui->rssi->setText(data[3]);
    ui->upload->setText(data[20]);
    ui->download->setText(data[21]);
    ui->uptime->setText(data[19]);
}
