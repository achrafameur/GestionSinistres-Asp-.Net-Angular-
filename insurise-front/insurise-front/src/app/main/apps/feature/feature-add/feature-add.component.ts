import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  NgForm,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ArticleService } from 'app/main/pages/article/article.service';
import { ChainService } from 'app/main/pages/chain/chain.service';
import { ChainDto } from 'app/main/pages/interfaces/chain';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { IFeatureItems } from 'app/main/pages/interfaces/featureItems';
import { Item } from 'app/main/pages/interfaces/item';
import { Nature } from 'app/main/pages/interfaces/nature';
import { NatureService } from 'app/main/pages/nature/nature.service';
import Swal from 'sweetalert2';
import { FeatureService } from '../feature.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-feature-add',
  templateUrl: './feature-add.component.html',
  styleUrls: ['./feature-add.component.scss'],
})
export class FeatureAddComponent implements OnInit {
  public contentHeader: object;

  public feature: FeatureDto;
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: FeatureDto;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  form: FormGroup;
  natureList: Nature[];
  chainList: ChainDto[];
  public itemList: Item[];
  public FeatureItemId: any;
  public itemIds: number[];
  public featureItems: any[] = [];
  public id: number;
  public featureIdd: any;

  constructor(
    private articleService: ArticleService,
    private featureService: FeatureService,
    private natureService: NatureService,
    private chainService: ChainService,
    private router: Router,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English,Francais);
  }
  addFeatureForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    description: new FormControl(''),
    symbol: new FormControl(''),
    natureId: new FormControl(''),
    chainId: new FormControl(''),
    fixed: new FormControl(''),
    minimum: new FormControl(''),
    maximum: new FormControl(''),
    alterable: new FormControl(''),
    isPrincipal: new FormControl(''),
    // item: new  FormControl('') ,
  });

  ngOnInit(): void {
   console.log(this.addFeatureForm.get("natureId").value.parseInt) 
    this.natureService.loadNatures().subscribe((data) => {
      this.natureList = data;
      this.chainService.loadChains().subscribe((data) => {
        this.chainList = data;
      });
    });
    this.articleService.loadItems().subscribe((data) => {
      this.itemList = data;
    });

    this.contentHeader = {
      headerTitle: ' Feature',
      actionButton: false,
      breadcrumb: {
        type: '',
        links: [
          {
            name: 'Home',
            isLink: true,
            link: '/',
          },
          {
            name: 'Feature',
            isLink: true,
            link: '/apps/feature/list',
          },
          {
            name: 'Add',
            isLink: false,
          },
        ],
      },
    };
  }

  onSubmit(featureItemsForm: NgForm) {
    if (this.addFeatureForm.valid) {
      console.log('Excecute create service', this.addFeatureForm.value);
      if(this.addFeatureForm.value.alterable==""){
        this.addFeatureForm.value.alterable =false;
      }
      if(this.addFeatureForm.value.isPrincipal==""){
        this.addFeatureForm.value.isPrincipal =false;
      }
      if(this.addFeatureForm.value.fixed==""){
        this.addFeatureForm.value.fixed =0;
      }
      if(this.addFeatureForm.value.maximum==""){
        this.addFeatureForm.value.maximum =0;
      }
      if(this.addFeatureForm.value.minimum==""){
        this.addFeatureForm.value.minimum =0;
      }
      this.addFeatureForm.value

      this.featureService
        .addFeature({
          ...this.addFeatureForm.value,
          chainId: Number.parseInt(this.addFeatureForm.value.chainId),
          natureId: Number.parseInt(this.addFeatureForm.value.natureId),
          
        })
        .subscribe({
          next: (data) => {
            this.featureIdd=data;
            console.log(data)

            this.FeatureItemId = this.itemList
            .filter(x => x.isChecked == true)
            .map(x => x.id)
            .toString();
          console.log(this.FeatureItemId);
          this.itemIds = this.FeatureItemId.split(',');
         
        // if(this.itemIds=[]){
        //   this.router.navigate(['/apps/feature/list']);

        // }
        // else{
          this.featureService.setFeatureItems(this.featureIdd, this.itemIds).subscribe({
            next: () => {
              console.log(this.itemIds)
              this.ConfirmTextOpen();
              this.router.navigate(['/apps/feature/list']);
            },
            error: (error) => {
              console.log(error);
            },
          });
        // }
          


          },
          error: (err) => {
            console.log(err);
          },
        });
    }
  }
  getNatureValue(id:string){
  id=(this.addFeatureForm.value.natureId) ;
  
  for (let i = 0; i < this.natureList.length; i++) {
    if(this.natureList[i].id == Number.parseInt(id)){
      return this.natureList[i].isList
    }
    
  }
  }
  onChange(){
    console.log(this.itemList)
  }
  change1(){
    if(this.addFeatureForm.get('fixed').value!=0){
      this.addFeatureForm.get('maximum').setValue(0);
      this.addFeatureForm.get('minimum').setValue(0);
      // this.addFeatureForm.get('maximum').disable();
      // this.addFeatureForm.get('minimum').disable();
    }
  }
  change2(){
    if((this.addFeatureForm.get('maximum').value!=0)&&(this.addFeatureForm.get('minimum').value!=0)){
      this.addFeatureForm.get('fixed').setValue(0);
      // this.addFeatureForm.get('fixed').disable();
    }
  }
  
  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new feature!",
      icon: 'success',
      confirmButtonColor: '#7367F0',
      cancelButtonColor: '#E42728',
      confirmButtonText: 'Ok',
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger ml-1'
      }
    }).then((result) =>{
      if (result) {
        // this.add();
      }
    });
  }

}

//   attachFeatureItems(featureItemsForm: NgForm) {
//     this.FeatureItemId = this.itemList
//       .filter((x) => x.isChecked == true)
//       .map((x) => x.id)
//       .toString();
//     console.log(this.FeatureItemId);
//     this.itemIds = this.FeatureItemId.split(',');
//     for (let i = 0; i < this.itemIds.length; i++) {
//       if (featureItemsForm.value.featureItemId == true) {
//         this.featureItems.push({
//           itemId: this.itemIds[i],
//         });
//       }
//     }
//     this.featureService.setFeatureItems(this.id, this.featureItems).subscribe({
//       next: () => {
//         this.router.navigate(['/apps/feature/list']);
//       },
//       error: (error) => {
//         console.log(error);
//       },
//     });
//   }
//   onChange() {
//     console.log(this.itemList);
//   }

//Origin

// if (this.addFeatureForm.valid) {
//   console.log("Excecute create service", this.addFeatureForm.value);

//   this.featureService.addFeature({...this.addFeatureForm.value, chainId:  Number.parseInt(this.addFeatureForm.value.chainId),natureId: Number.parseInt(this.addFeatureForm.value.natureId)  }).subscribe({
//     next: () => {

//         this.router.navigate(["/apps/feature/list"])
//     },
//     error: (err) => {
//       console.log(err)
//     }
//   });
// }
//end origin
