QT       += core gui network
greaterThan(QT_MAJOR_VERSION, 4): QT += widgets
TARGET = BilaI-PnP-Gui
TEMPLATE = app
SOURCES += main.cpp\
        mainwindow.cpp \
    statusinfo.cpp
HEADERS  += mainwindow.h \
    statusinfo.h
FORMS    += mainwindow.ui
