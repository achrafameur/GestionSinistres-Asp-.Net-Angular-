import {CoreMenu} from '@core/types';

//? DOC: http://localhost:7777/demo/vuexy-angular-admin-dashboard-template/documentation/guide/development/navigation-menus.html#interface

export const menu: CoreMenu[] = [
     // Dashboard
  // {
  //   id: 'dashboard',
  //   title: 'Dashboard',
  //   translate: 'MENU.DASHBOARD.COLLAPSIBLE',
  //   type: 'collapsible',
  //   // role: ['Admin'], //? To hide collapsible based on user role
  //   icon: 'home',
  //   badge: {
  //     title: '2',
  //     translate: 'MENU.DASHBOARD.BADGE',
  //     classes: 'badge-light-warning badge-pill'
  //   },
  //   children: [
  //     {
  //       id: 'analytics',
  //       title: 'Analytics',
  //       translate: 'MENU.DASHBOARD.ANALYTICS',
  //       type: 'item',
  //       role: ['Admin'], //? To set multiple role: ['Admin', 'Client']
  //       icon: 'circle',
  //       url: 'dashboard/analytics'
  //     },
  //     {
  //       // If role is not assigned will be display to all
  //       id: 'ecommerce',
  //       title: 'eCommerce',
  //       translate: 'MENU.DASHBOARD.ECOMMERCE',
  //       type: 'item',
  //       icon: 'circle',
  //       url: 'dashboard/ecommerce'
  //     }
  //   ]
  // },
 
    // Production
    {
        id: 'production',
        type: 'section' , 
        title: 'Production',
        translate: 'MENU.PRODUCTION.SECTION',
        icon: 'package',
        children: [
            {
                id: 'branch',
                title: 'Branch',
                translate: 'MENU.PRODUCTION.BRANCH',
                type: 'item',
                icon: 'box',
                url: 'apps/branch/list'
            },
            // {
            //     id: 'quotation',
            //     title: 'Quotation',
            //     translate: 'MENU.PRODUCTION.QUOTATION',
            //     type: 'item',
            //     icon: 'box',
            //     url: 'apps/quotation/list'
            // },
            {
                id: 'product',
                title: 'Product',
                translate: 'MENU.PRODUCTION.PRODUCT',
                type: 'item',
                icon: 'box',
                url: 'apps/product'
            },
            {
                id: 'warranty',
                title: 'Warranty',
                translate: 'MENU.PRODUCTION.WARRANTY',
                type: 'item',
                icon: 'box',
                url: 'apps/warranty/list'
            },
            {
                id: 'feature',
                title: 'Feature',
                translate: 'MENU.PRODUCTION.FEATURE',
                type: 'item',
                icon: 'box',
                url: 'apps/feature/list'
            },
            {
                id: 'tax',
                title: 'Tax',
                translate: 'MENU.PAGES.BASIC_SETTING.TAX',
                type: 'item',
                icon: 'box',
                url: 'apps/tax/list'
                
            },
            {
                id: 'fees',
                title: 'Fees',
                translate: 'MENU.PAGES.BASIC_SETTING.FEES',
                type: 'item',
                icon: 'box',
                url: 'apps/fees/list'
                
            },
            {
                id: 'commission',
                title: 'Commission',
                translate: 'MENU.PRODUCTION.COMMISSION',
                type: 'item',
                icon: 'box',
                url: 'apps/commission/list'
                
            },
            {
                id: 'basic-setting',
                title: 'Basic setting',
                translate: 'MENU.PAGES.BASIC_SETTING.COLLAPSIBLE',
                type: 'collapsible',
                icon: 'file-text',
                children: [
                    {
                        id: 'chain',
                        title: 'Chain',
                        translate: 'MENU.PAGES.BASIC_SETTING.CHAIN',
                        type: 'item',
                        icon: 'file-text',
                        url: 'apps/chain/list'
                      },
                      {
                        id: 'nature',
                        title: 'Nature',
                        translate: 'MENU.PAGES.BASIC_SETTING.NATURE',
                        type: 'item',
                        icon: 'file-text',
                        url: 'apps/nature/list'
                    },
                    {
                        id: 'article',
                        title: 'Article',
                        translate: 'MENU.PAGES.BASIC_SETTING.ARTICLE',
                        type: 'item',
                        icon: 'file-text',
                        url: 'apps/article/list'
                        // collapsed: true
                      },
                      {
                        id: 'duration',
                        title: 'Duration',
                        translate: 'MENU.PAGES.BASIC_SETTING.DURATION',
                        type: 'item',
                        icon: 'file-text',
                        url: 'apps/duration/list'
                        
                      },
                      {
                        id: 'proportion',
                        title: 'Proportion',
                        // translate: 'MENU.PAGES.BASIC_SETTING.PROPORTION',
                        type: 'item',
                        icon: 'file-text',
                        url: 'apps/proportion/list'
                    },
                    //   {
                    //     id: 'element',
                    //     title: 'Element',
                    //     // translate: 'MENU.PAGES.BASIC_SETTING.PROPORTION',
                    //     type: 'item',
                    //     icon: 'file-text',
                    //     url: 'pages/chain-element/list'
                    //   },
                ]
            }
        ]
    },
    // Sinister
    {
        id: 'sinister',
        type: 'section',
        title: 'Sinister',
        translate: 'MENU.SINISTER.SECTION',
        icon: 'layers',
        children: [
            {
                id: 'sinisterNature',
                title: 'Sinister Nature',
                translate: 'MENU.SINISTER.SINISTER_NATURE',
                type: 'item',
                icon: 'layers',
                url: 'apps/sinisterNature/list'
            },
            {
                id: 'status',
                title: 'Status',
                translate: 'MENU.SINISTER.STATUS',
                type: 'item',
                icon: 'layers',
                url: 'apps/status/list'
            },
            {
                id: 'expert',
                title: 'Expert',
                translate: 'MENU.SINISTER.EXPERT',
                type: 'item',
                icon: 'layers',
                url: 'apps/expert/list'
            },
            {
                id: 'third-party',
                title: 'Third Party',
                translate: 'MENU.SINISTER.THIRD_PARTY',
                type: 'item',
                icon: 'layers',
                url: 'apps/third-party/list'
            },
            {
                id: 'third-company',
                title: 'Third Company',
                translate: 'MENU.SINISTER.THIRD_COMPANY',
                type: 'item',
                icon: 'layers',
                url: 'apps/third-company/list'
            },
            {
                id: 'average-cost',
                title: 'Average Cost',
                translate: 'MENU.SINISTER.AVERAGE_COST',
                type: 'item',
                icon: 'layers',
                url: 'apps/average-cost/list'
            },
            {
                id: 'Sinister-Declaration',
                title: 'Declare Sinister',
                translate: 'MENU.SINISTER.SINISTERDECLARATION',
                type: 'item',
                icon: 'layers',
                url: 'apps/Sinister-Declaration/add'
            },
            {
                id: 'Sinister-List',
                title: 'Sinister Binders List',
                translate: 'MENU.SINISTER.SINISTERLIST',
                type: 'item',
                icon: 'layers',
                url: 'apps/SinisterBinders/all'
            }
        ]
    }
];
