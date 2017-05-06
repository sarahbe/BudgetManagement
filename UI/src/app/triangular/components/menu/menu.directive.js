﻿(function() {
    'use strict';

    angular
        .module('triangular.components')
        .directive('triMenu', triMenuDirective);

    /* @ngInject */
    function triMenuDirective($location, $mdTheming, triTheming) {
        // Usage:
        //
        // Creates:
        //
        var directive = {
            restrict: 'E',
            template: '<md-content><tri-menu-item ng-repeat="item in triMenuController.menu | orderBy:\'priority\'" item="::item"></tri-menu-item></md-content>' +
            '<md-content style="position:fixed;bottom:0;width:100%;"><tri-menu-item ng-repeat="item in triMenuController.bottomMenu | orderBy:\'priority\'" item="::item"></tri-menu-item></md-content>',
            scope: {},
            controller: triMenuController,
            controllerAs: 'triMenuController',
            link: link
        };
        return directive;

        function link($scope, $element) {
            $mdTheming($element);
            var $mdTheme = $element.controller('mdTheme'); //eslint-disable-line

            var menuColor = triTheming.getThemeHue("blackadisyo", 'primary', 'default');
            var menuColorRGBA = triTheming.rgba(menuColor.value);
            $element.css({ 'background-color': menuColorRGBA });
            $element.children('md-content').css({ 'background-color': menuColorRGBA });
        }
    }

    /* @ngInject */
    function triMenuController(triMenu) {
        var triMenuController = this;
        // get the menu and order it
        // get the menu and order it
        triMenuController.menu = getMenuItems(undefined);
        triMenuController.bottomMenu = getMenuItems("bottom");


        function getMenuItems(item) {

            var foundedItem = window._.filter(triMenu.menu, function (menuItem) {
                return menuItem.position == item;
            });
            return foundedItem;
        }
    }
})();
