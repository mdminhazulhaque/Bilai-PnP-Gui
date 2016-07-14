#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "statusinfo.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void loggedIn();
    void setStatus(QString info);

private:
    Ui::MainWindow *ui;
    StatusInfo *stat;
};

#endif // MAINWINDOW_H
