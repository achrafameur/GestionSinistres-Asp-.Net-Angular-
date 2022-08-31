import { Component, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { ArticleService } from '../article.service';
import { Router } from '@angular/router';
import { Item } from 'app/main/pages/interfaces/item';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-article-add',
  templateUrl: './article-add.component.html',
  styleUrls: ['./article-add.component.scss']
})
export class ArticleAddComponent implements OnInit {

  public article:Item; 
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: Item;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public contentHeader: object;
  constructor(private articleService:ArticleService, private router: Router,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  addArticleForm = new FormGroup({
    title: new FormControl('', [
      Validators.required,
    ]),
  });

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: ' Article',
      actionButton: false,
      breadcrumb: {
          type: '',
          links: [
              {
                  name: 'Home',
                  isLink: true,
                  link: '/'
              },
              {
                  name: 'Article',
                  isLink: true,
                  link: '/apps/article/list'
              },
              {
                  name: 'Add',
                  isLink: false
              }
          ]
      }
  };
  }

  onSubmit() {
    if (this.addArticleForm.valid) {
      console.log("Excecute create service", this.addArticleForm.value);
      this.articleService.createItem(this.addArticleForm.value).subscribe({
        next: () => {
          this.ConfirmTextOpen();
            this.router.navigate(["/apps/article/list"])
        },
        error: (err) => {
          console.log(err)
        }
      });
  }
}

ConfirmTextOpen(){
  Swal.fire({
    title: 'Success!',
    text: "You have successfully added a new article!",
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
