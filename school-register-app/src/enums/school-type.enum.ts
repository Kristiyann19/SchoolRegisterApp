export enum SchoolTypeEnum{
  state = 1,
  municipal = 2,
  private = 3
}


export const SchoolTypeEnumLocalization = {
  [SchoolTypeEnum.state]: 'Държавно',
  [SchoolTypeEnum.municipal]: 'Общинско',
  [SchoolTypeEnum.private]: 'Частно'

}