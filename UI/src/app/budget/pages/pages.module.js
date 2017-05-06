(function() {
    'use strict';

    angular
        .module('app.budget.pages', [

        ]).run(function (editableOptions, editableThemes) {
            editableOptions.theme = 'default';
            editableThemes['default'].submitTpl = '<md-button type="submit" class="md-icon-button md-accent"><md-icon style="font-size:32px;"  md-font-icon="zmdi zmdi-check"></md-icon></md-button>';
            editableThemes['default'].cancelTpl = '<md-button ng-click="$form.$cancel()" class="md-icon-button md-accent"><md-icon style="font-size:32px;"  md-font-icon="zmdi zmdi-close"></md-icon></md-button>';
        });;

})();