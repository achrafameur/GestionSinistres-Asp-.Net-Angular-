import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElementUpdateComponent } from './element-update.component';

describe('ElementUpdateComponent', () => {
  let component: ElementUpdateComponent;
  let fixture: ComponentFixture<ElementUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ElementUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ElementUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
